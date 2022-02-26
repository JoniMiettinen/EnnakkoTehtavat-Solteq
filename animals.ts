namespace PreAssignment {

    //Toimisiko esim. animal-luokka johon voi laittaa lisäominaisuuksia, jonka cat ja dog perii?
    //PrintCats- ja PrintDogs-funktiot voisi myös varmaan yhdistää yhdeksi funktioksi?

    export class Cat {
        private name: string;
        private age: number;

        constructor(_name: string, _age: number) {
            this.name = _name;
            this.age = _age;
        }

        get(): object {
            return {
                "name": this.name,
                "age": this.age
            };
        }
    }

    export class Dog {
        private name: string;
        private age: number;
        private color: string;

        constructor(_name: string, _age: number, _color: string) {
            this.name = _name;
            this.age = _age;
            this.color = _color;
        }

        get(): object {
            return {
                "name": this.name,
                "age": this.age,
                "color": this.color
            };
        }
    }

    
    export function PrintCats(cats: Cat[], addHeader: boolean): string {
        var html: string;
        var data: object;
        html = "";

		if (addHeader) {
            data = cats[0].get();
			var keys = Object.keys(data);

			html += "<div class='row header'>";

			for (var key in keys) {
				html += "<div class='col-1'>"+ keys[key] +"</div>";
			}

			html += "</div>";
		}

        for (var i in cats) {
            data = cats[i].get();

            var values = Object.values(data);
            html += "<div class='row'>";

            for (var val in values) {
                html += "<div class='col-1'>" + values[val] + "</div>";
            }

            html += "</div>";
        }

        return html;
    }

    export function PrintDogs(dogs: Dog[], addHeader: boolean): string {
        var html: string;
        var data: object;
        html = "";

		if (addHeader) {
            data = dogs[0].get();
			var keys = Object.keys(data);

			html += "<div class='row header'>";

			for (var key in keys) {
				html += "<div class='col-1'>" + keys[key] + "</div>";
			}

			html += "</div>";
		}

        for (var i in dogs) {
            data = dogs[i].get();

            var values = Object.values(data);
            html += "<div class='row'>";

            for (var val in values) {
                html += "<div class='col-1'>" + values[val] + "</div>";
            }

            html += "</div>";
        }

        return html;
    }
}

// This is just init data, ignore code below this line in the task
const catsInitData = ["Leo","Bella","Milo","Charlie","Kitty","Lucy","Nala","Simba","Jack","Loki"];
const dogsInitData = ["Max", "Coco", "Rex", "Bella", "Scooby", "Rocky", "Daisy", "Fluffy", "Buddy", "Duke"];

document.addEventListener("DOMContentLoaded", function () {
    var catArray: PreAssignment.Cat[] = [];
    var dogArray: PreAssignment.Dog[] = [];
    var age: number = 0;

    for (var i in catsInitData) {
        catArray.push(new PreAssignment.Cat(catsInitData[i], ++age));
        dogArray.push(new PreAssignment.Dog(dogsInitData[i], age, (age % 2 == 0 ? "brown" : age % 3 == 0 ? "yellow" : "black")));
    }

    let catsContainer = document.getElementById('catsContainer');
    if (catsContainer) {
        (catsContainer as HTMLFormElement).innerHTML = PreAssignment.PrintCats(catArray, true);
    }
    let dogsContainer = document.getElementById('dogsContainer');
    if (dogsContainer) {
        (dogsContainer as HTMLFormElement).innerHTML = PreAssignment.PrintDogs(dogArray, true);
    }
});
