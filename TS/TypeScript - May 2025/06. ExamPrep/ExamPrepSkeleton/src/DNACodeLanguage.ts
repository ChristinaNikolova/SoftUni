import { Language } from "./contracts/language";
import { DNACodeCharacter } from "./types";

export class DNACodeLanguage implements Language {
  private _charset: Set<DNACodeCharacter> = new Set(["A", "C", "G", "T"]);

  get charset(): Set<DNACodeCharacter> {
    return this._charset;
  }

  isCompatibleToCharset(message: string): boolean {
    let allChars = message.split("");
    const validSymbol = ["A", "C", "G", "T"];
    let isCompatible = allChars.every((x) => validSymbol.includes(x));
    return isCompatible;
  }
}
