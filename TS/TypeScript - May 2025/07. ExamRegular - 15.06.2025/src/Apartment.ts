import { Room } from "./contracts/room";
import { RoomNumber } from "./types";

export class Apartment implements Room {
  readonly roomNumber: RoomNumber;
  readonly totalPrice: number;
  readonly cancellationPrice: number;

  constructor(price: number, roomNumber: RoomNumber, numberOfGuests: number) {
    this.roomNumber = roomNumber;
    this.totalPrice = price * numberOfGuests;
    this.cancellationPrice = this.totalPrice * 0.8;
  }
}
