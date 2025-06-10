enum LoggingLevel {
  Info = "Info",
  Error = "Error",
  Warning = "Warning",
  Debug = "Debug",
}

enum LoggingFormat {
  Standard = "[%level][%date] %text",
  Minimal = "*%level* %text",
}

interface CachingLogger<T extends LoggingLevel, V extends LoggingFormat> {
  cachedLogs: Map<T, string[]>;
  log(logLevel: T, message: string): void;
  getFormat(): V;
}

class Logger<T extends LoggingLevel, V extends LoggingFormat>
  implements CachingLogger<T, V>
{
  private format: V;
  cachedLogs: Map<T, string[]>;

  constructor(format: V) {
    this.format = format;
    this.cachedLogs = new Map<T, string[]>();
  }

  log(logLevel: T, message: string): void {
    const formattedMessage = this.format
      .replace("%level", logLevel)
      .replace("%date", new Date().toISOString())
      .replace("%text", message);
    console.log(formattedMessage);

    const currentMessages = this.cachedLogs.get(logLevel);

    if (currentMessages) {
      currentMessages.push(formattedMessage);
    } else {
      this.cachedLogs.set(logLevel, [formattedMessage]);
    }
  }

  getFormat(): V {
    return this.format;
  }
}

let logger1 = new Logger<LoggingLevel, LoggingFormat>(LoggingFormat.Standard);
logger1.log(LoggingLevel.Info, "This is an info message.");
logger1.log(LoggingLevel.Info, "Another message.");
logger1.log(LoggingLevel.Error, "Something went wrong.");
logger1.log(LoggingLevel.Warning, "Be careful with the type assertions.");
logger1.log(LoggingLevel.Debug, "Running the debugger.");
console.log("-----------");
console.log(
  [...logger1.cachedLogs.entries()].map((x) => x[1].join("\n")).join("\n")
);

let logger2 = new Logger<LoggingLevel, LoggingFormat>(LoggingFormat.Minimal);
logger2.log(LoggingLevel.Info, "Just a simple message.");
logger2.log(LoggingLevel.Error, "A Problem happened.");
console.log("-----------");
console.log(logger2.getFormat());
console.log(
  [...logger2.cachedLogs.entries()].map((x) => x[1].join("\n")).join("\n")
);

// TS error
// let logger3 = new Logger<LoggingLevel, LoggingFormat>("%text");
// let wronglogger = new Logger<string, LoggingLevel>();
// logger3.log("%s", "Running the debugger.");
// logger3.log({ format: "Test %s" }, "Running the debugger.");
