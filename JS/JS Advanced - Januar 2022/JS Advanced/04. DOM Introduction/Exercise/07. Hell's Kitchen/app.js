function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);

   function onClick() {
      let inputsTextAreaElement = document.querySelector('div#inputs textarea');

      const inputAsArray = JSON.parse(inputsTextAreaElement.value);

      const restaurants = inputAsArray.reduce((acc, curr) => {
         let [name, workers] = curr.split('-').map((x) => x.trim());

         let currentRestaurant = acc.find((x) => x.name === name);

         if (!currentRestaurant) {
            currentRestaurant = {
               name,
               workers: [],
               sumSalaries: 0,
               averageSalary: 0,
               bestSalary: 0,
            };

            acc.push(currentRestaurant);
         }

         workers = workers.split(',').map((x) => x.trim());

         workers.forEach((worker) => {
            let [workerName, salary] = worker.split(' ').map((x) => x.trim());
            salary = Number(salary);

            const newWorker = {
               name: workerName,
               salary,
            };

            currentRestaurant.workers.push(newWorker);
            currentRestaurant.sumSalaries += salary;
         });

         currentRestaurant.averageSalary = currentRestaurant.sumSalaries / currentRestaurant.workers.length;
         currentRestaurant.bestSalary = currentRestaurant.workers.sort((a, b) => b.salary - a.salary)[0].salary;

         return acc;
      }, []);

      const bestRestaurant = restaurants.sort((a, b) => b.averageSalary - a.averageSalary)[0];

      let bestRestaurantPElement = document.querySelector('div#bestRestaurant p');
      bestRestaurantPElement.textContent = `Name: ${bestRestaurant.name} Average Salary: ${bestRestaurant.averageSalary.toFixed(2)} Best Salary: ${bestRestaurant.bestSalary.toFixed(2)}`;

      const sortedWorkers = bestRestaurant.workers.sort((a, b) => b.salary - a.salary);
      let messageToPrint = '';

      sortedWorkers.forEach((worker) => {
         messageToPrint += `Name: ${worker.name} With Salary: ${worker.salary} `;
      });

      let workersPElement = document.querySelector('div#workers p');
      workersPElement.textContent = messageToPrint.trimEnd();

      inputsTextAreaElement.value = '';
   }
}