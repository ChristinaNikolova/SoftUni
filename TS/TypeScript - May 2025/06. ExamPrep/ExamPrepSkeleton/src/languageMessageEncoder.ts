import { Cipher } from "./contracts/cipher";
import { PartialMessageEncoder } from "./contracts/implemented/partialMessageEncoder";
import { Language } from "./contracts/language";
import { MessageEncoder } from "./contracts/messageEncoder";
import { ProcessedCharacter } from "./types";

export class LanguageMessageEncoder<T extends Language, V extends Cipher<T>>
  extends PartialMessageEncoder
  implements MessageEncoder
{
  private totalEncodedChars: number;
  private totalDecodedChars: number;

  constructor(language: T, cipher: V) {
    super(language, cipher);
    this.totalEncodedChars = 0;
    this.totalDecodedChars = 0;
  }

  override encodeMessage(secretMessage: unknown): string {
    if (typeof secretMessage !== "string" || !secretMessage.length) {
      return "No message.";
    }

    const strippedMessage = this.stripForbiddenSymbols(secretMessage);
    const isCompatible = this.language.isCompatibleToCharset(strippedMessage);

    if (!isCompatible) {
      return "Message not compatible.";
    }

    const result = this.cipher.encipher(strippedMessage);
    this.totalEncodedChars += result.length;

    return result;
  }

  override decodeMessage(secretMessage: unknown): string {
    if (typeof secretMessage !== "string" || !secretMessage.length) {
      return "No message.";
    }

    const isCompatible = this.language.isCompatibleToCharset(secretMessage);

    if (!isCompatible) {
      return "Message not compatible.";
    }

    const result = this.cipher.decipher(secretMessage);
    this.totalDecodedChars += result.length;

    return result;
  }

  override totalProcessedCharacters(type: ProcessedCharacter): string {
    let result = 0;

    switch (type) {
      case "Encoded":
        result = this.totalEncodedChars;
        break;
      case "Decoded":
        result = this.totalDecodedChars;
        break;
      case "Both":
        result = this.totalEncodedChars + this.totalDecodedChars;
        break;
    }

    return `Total processed characters count: ${result}`;
  }

  protected override stripForbiddenSymbols(message: string): string {
    let forbiddenSymbols = PartialMessageEncoder.forbiddenSymbols;
    forbiddenSymbols.forEach((x) => (message = message.replaceAll(x, "")));
    return message;
  }
}
