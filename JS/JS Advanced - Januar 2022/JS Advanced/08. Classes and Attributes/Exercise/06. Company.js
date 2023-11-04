class Company {
    constructor() {
        this.departments = {};
    }

    addEmployee(name, salary, position, department) {
        if (!name || !salary || !position || !department || salary < 0) {
            throw new Error('Invalid input!');
        }

        if (!this.departments.hasOwnProperty(department)) {
            this.departments[department] = {
                employees: [],
                totalSalaries: 0,
                avgSalary: 0,
            };
        }

        salary = Number(salary);

        const employee = {
            name,
            salary,
            position,
        };

        this.departments[department].employees.push(employee);
        this.departments[department].totalSalaries += salary;
        this.departments[department].avgSalary = this.departments[department].totalSalaries / this.departments[department].employees.length;

        return `New employee is hired. Name: ${name}. Position: ${position}`;
    }

    bestDepartment() {
        const bestDepartment = Object.keys(this.departments).sort((a, b) => b.avgSalary - a.avgSalary)[0];

        let messageToPrint = `Best Department is: ${bestDepartment}\nAverage salary: ${this.departments[bestDepartment].avgSalary.toFixed(2)}\n`;

        const sortedBestEmployees = this.departments[bestDepartment].employees.sort((a, b) => b.salary - a.salary || a.name.localeCompare(b.name));

        sortedBestEmployees.forEach((emp) => {
            messageToPrint += `${emp.name} ${emp.salary} ${emp.position}\n`;
        })

        return messageToPrint.trimEnd();
    }
}

let c = new Company();
c.addEmployee("Stanimir", 2000, "engineer", "Construction");
c.addEmployee("Pesho", 1500, "electrical engineer", "Construction");
c.addEmployee("Slavi", 500, "dyer", "Construction");
c.addEmployee("Stan", 2000, "architect", "Construction");
c.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing");
c.addEmployee("Pesho", 1000, "graphical designer", "Marketing");
c.addEmployee("Gosho", 1350, "HR", "Human resources");
console.log(c.bestDepartment()); 