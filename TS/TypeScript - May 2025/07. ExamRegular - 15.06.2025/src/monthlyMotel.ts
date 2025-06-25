import { Motel } from "./contracts/motel";
import { PartialMonthlyMotel } from "./contracts/partialMonthlyMotel";
import { Room } from "./contracts/room";
import { MonthType, RoomNumber } from "./types";

export class MonthlyMotel<T extends MonthType>
  extends PartialMonthlyMotel
  implements Motel
{
  private rooms: Map<RoomNumber, Room>;
  private bookings: Map<RoomNumber, Set<T>>;
  private totalBudget: number;

  constructor() {
    super();
    this.rooms = new Map();
    this.bookings = new Map();
    this.totalBudget = 0;
  }

  override addRoom(room: unknown): string {
    if (!this.isRoom(room)) {
      return "Value was not a Room.";
    }

    if (this.rooms.has(room.roomNumber)) {
      return `Room '${room.roomNumber}' already exists.`;
    }

    this.rooms.set(room.roomNumber, room);
    this.bookings.set(room.roomNumber, new Set());

    return `Room '${room.roomNumber}' added.`;
  }

  override bookRoom(roomNumber: RoomNumber, bookedMonth: T): string {
    const room = this.rooms.get(roomNumber);

    if (!room) {
      return `Room '${roomNumber}' does not exist.`;
    }

    const roomBookings = this.bookings.get(roomNumber)!;

    if (roomBookings.has(bookedMonth)) {
      return `Room '${roomNumber}' is already booked for '${bookedMonth}'.`;
    }

    roomBookings.add(bookedMonth);
    this.totalBudget += room.totalPrice;

    return `Room '${roomNumber}' booked for '${bookedMonth}'.`;
  }

  override cancelBooking(roomNumber: RoomNumber, bookedMonth: T): string {
    const room = this.rooms.get(roomNumber);

    if (!room) {
      return `Room '${roomNumber}' does not exist.`;
    }

    const roomBookings = this.bookings.get(roomNumber)!;

    if (!roomBookings.has(bookedMonth)) {
      return `Room '${roomNumber}' is not booked for '${bookedMonth}'.`;
    }

    roomBookings.delete(bookedMonth);
    this.totalBudget -= room.cancellationPrice;

    return `Booking cancelled for Room '${roomNumber}' for '${bookedMonth}'.`;
  }

  override getTotalBudget(): string {
    return (
      `Motel: ${PartialMonthlyMotel.MotelName}` +
      "\n" +
      `Total budget: $${this.totalBudget.toFixed(2)}`
    );
  }

  private isRoom(obj: unknown): obj is Room {
    const validRoomNumbers = ["A01", "A02", "A03", "B01", "B02", "B03"];

    return (
      obj !== null &&
      typeof obj === "object" &&
      "roomNumber" in obj &&
      typeof obj.roomNumber === "string" &&
      validRoomNumbers.includes(obj.roomNumber) &&
      "totalPrice" in obj &&
      typeof obj.totalPrice === "number" &&
      "cancellationPrice" in obj &&
      typeof obj.cancellationPrice === "number"
    );
  }
}
