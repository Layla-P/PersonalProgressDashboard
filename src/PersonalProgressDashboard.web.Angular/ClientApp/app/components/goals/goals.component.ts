import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { Goal } from '../../models/goalmodel'

@Component({
    selector: 'goals',
    templateUrl: './goals.component.html'
})
export class GoalsComponent {
    public goals: Goal[];

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        http.get('http://personal-progress-dashboard-api.azurewebsites.net/api/PersonalGoals').subscribe(result => {
            console.log(result);
            this.goals = result.json() as Goal[];
        }, error => console.error(error));
    }
}


//http://personal-progress-dashboard-api.azurewebsites.net/api/PersonalGoals
//http://localhost:53330/api/PersonalGoals