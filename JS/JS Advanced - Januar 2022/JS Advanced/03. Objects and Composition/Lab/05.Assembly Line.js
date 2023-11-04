function createAssemblyLine() {
    const obj = {
        hasClima: function (car) {
            car.temp = 21;
            car.tempSettings = 21;
            car.adjustTemp = function () {
                if (this.temp < this.tempSettings) {
                    this.temp += 1;
                } else if (this.temp > this.tempSettings) {
                    this.temp -= 1;
                }
            }
        },
        hasAudio: function (car) {
            car.currentTrack = {
                name: null,
                artist: null,
            };
            car.nowPlaying = function () {
                if (this.currentTrack.name && this.currentTrack.artist) {
                    console.log(`Now playing '${this.currentTrack.name}' by ${this.currentTrack.artist}`);
                }
            }
        },
        hasParktronic: function (car) {
            let messageToPrint = '';

            car.checkDistance = function (distance) {
                if (distance < 0.1) {
                    messageToPrint = 'Beep! Beep! Beep!'
                } else if (distance < 0.25) {
                    messageToPrint = 'Beep! Beep!'
                } else if (distance < 0.5) {
                    messageToPrint = 'Beep!'
                }

                console.log(messageToPrint);
            }
        },
    };

    return obj;
}

const assemblyLine = createAssemblyLine();
const myCar = {
    make: 'Toyota',
    model: 'Avensis'
};

assemblyLine.hasClima(myCar);
console.log(myCar.temp);
myCar.tempSettings = 18;
myCar.adjustTemp();
console.log(myCar.temp);

assemblyLine.hasAudio(myCar);
myCar.currentTrack = {
    name: 'Never Gonna Give You Up',
    artist: 'Rick Astley'
};
myCar.nowPlaying();

assemblyLine.hasParktronic(myCar);
myCar.checkDistance(0.4);
myCar.checkDistance(0.2);

console.log(myCar); 