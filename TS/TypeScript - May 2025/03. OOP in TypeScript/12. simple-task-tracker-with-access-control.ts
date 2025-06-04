class Task {
  title: string;
  description: string;
  completed = false;
  private _createdBy: string;

  constructor(title: string, description: string, createdBy: string) {
    this.title = title;
    this.description = description;
    this._createdBy = createdBy;
  }

  get createdBy() {
    return this._createdBy;
  }

  toggleStatus(): void {
    this.completed = !this.completed;
  }

  getDetails(): string {
    return `Task: ${this.title} - ${this.description} - ${
      this.completed ? "Completed" : "Pending"
    }`;
  }

  static createSampleTasks(): Task[] {
    return [
      new Task("first", "first desc...", "Misho"),
      new Task("second", "second desc...", "Maya"),
    ];
  }
}

const task1 = new Task("Complete homework", "Finish math exercises", "Charlie");
task1.toggleStatus();
console.log(task1.getDetails());

const task2 = new Task("Clean room", "Clean the room", "Mary");
console.log(task2.getDetails());

const tasks = Task.createSampleTasks();
tasks.forEach((task) => {
  task.toggleStatus();
  console.log(task.getDetails());
});
