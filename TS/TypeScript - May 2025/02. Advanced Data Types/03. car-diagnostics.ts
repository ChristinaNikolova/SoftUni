function startCarDiagnostics(): void {
  type CarBody = {
    material: string;
    state: string;
  };

  type Tires = {
    airPressure: number;
    condition: string;
  };

  type Engine = {
    horsepower: number;
    oilDensity: number;
  };

  type Diagnostic = {
    partName: string;
    runDiagnostics: () => string;
  };

  function carDiagnostics(
    carBody: CarBody & Diagnostic,
    tires: Tires & Diagnostic,
    engine: Engine & Diagnostic
  ): void {
    console.log(
      carBody.runDiagnostics() +
        "\n" +
        tires.runDiagnostics() +
        "\n" +
        engine.runDiagnostics()
    );
  }

  carDiagnostics(
    {
      material: "aluminum",
      state: "scratched",
      partName: "Car Body",
      runDiagnostics() {
        return this.partName;
      },
    },
    {
      airPressure: 30,
      condition: "needs change",
      partName: "Tires",
      runDiagnostics() {
        return this.partName;
      },
    },
    {
      horsepower: 300,
      oilDensity: 780,
      partName: "Engine",
      runDiagnostics() {
        return this.partName;
      },
    }
  );
}

startCarDiagnostics();
