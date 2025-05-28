function startExtractInterfaces(): void {
  type Status = "Logged" | "Started" | "InProgress" | "Done";

  type User = {
    username: string;
    signupDate: Date;
  };

  type Task = {
    status: Status;
    title: string;
    daysRequired: number;
    assignedTo: User | undefined;
    changeStatus(newStatus: Status): void;
  };

  function assignTask(user: User, task: Task) {
    if (task.assignedTo == undefined) {
      task.assignedTo = user;
      console.log(`User ${user.username} assigned to task '${task.title}'`);
    }
  }

  let user = {
    username: "Margaret",
    signupDate: new Date(2022, 1, 13),
    passwordHash: "random",
  };

  let task1 = {
    status: "Logged" as Status,
    title: "Need assistance",
    daysRequired: 1,
    assignedTo: undefined,
    changeStatus(newStatus: Status) {
      this.status = newStatus;
    },
  };

  let task2 = {
    status: "Done" as Status,
    title: "Test",
    daysRequired: 12,
    assignedTo: undefined,
    changeStatus(newStatus: Status) {
      this.status = newStatus;
    },
    moreProps: 300,
    evenMore: "wow",
  };

  assignTask(user, task1);
  assignTask(user, task2);
}

startExtractInterfaces();
