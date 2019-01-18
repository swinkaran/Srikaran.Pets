import { Component, Inject } from "@angular/core";
import { Http } from '@angular/http';

@Component({
    selector: 'pets-list',
    templateUrl: './pets.component.html',
    styleUrls: ['./pets.component.css']
})

export class PetsComponent {
    public ownerPets: OwnerPet[] = [];
    
    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        http.get(baseUrl + 'api/pets/cat').subscribe(result => {
            this.ownerPets = result.json() as OwnerPet[];
        }, error => console.error(error));
    }
}

interface OwnerPet {
    gender: string;
    pets: string[];
}