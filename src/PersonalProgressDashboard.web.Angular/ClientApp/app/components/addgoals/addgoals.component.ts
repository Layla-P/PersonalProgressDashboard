import { Component, Inject, Input, OnInit, OnDestroy } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Goal } from '../../models/goalmodel';
import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';

@Component({
    selector: 'addgoals',
    templateUrl: './addgoals.component.html'
})
export class AddGoalsComponent {

    private goal: Goal;
    private errorMessage: string;
    public goalForm: FormGroup; // model driven form
    public submitted: boolean; // keep track on whether form is submitted
    public formSaved: boolean; // keep track on whether form has been successfully saved
    public events: any[] = []; // use to display form changes
    private sub: any;
    private _http: Http;


    constructor(private _fb: FormBuilder, http: Http) {
    this._http = http} // form builder simplify form initialization


    ngOnInit() {
        this.submitted = false;

        this.goalForm = this._fb.group({
            id: [''],
            goalText: ['', [<any>Validators.required, <any>Validators.minLength(5), <any>Validators.maxLength(250)]],
            achieveByDate: ['', [<any>Validators.required]],
            achievedDate: ['', [<any>Validators.required]]
        });
      
    }

    ngOnDestroy() {
        if (this.sub) {
            this.sub.unsubscribe();
        }
    }

    save(model: Goal, isValid: boolean) {
        this.submitted = true; // set form submit to true
        console.log(model);
        // check if model is valid
        // if valid, call API to save customer
        let g: Goal = { isAchieved: false, achieveByDate: model.achieveByDate,achievedDate:"", goalText:model.goalText};
       

            let headers = new Headers({ 'Content-Type': 'application/json' });
            let options = new RequestOptions({ headers: headers }); //make sure headers are set correctly so that you avoid http415 errors (content-type accept)
            let b = JSON.stringify(g);
            console.log(b);
           
            return this._http.post(
               "http://personal-progress-dashboard-api.azurewebsites.net/api/PersonalGoals",
               b,
                options
            );
    }
  


    private toDateString(date: Date): string {
        return (date.getFullYear().toString() + '-'
            + ("0" + (date.getMonth() + 1)).slice(-2) + '-'
            + ("0" + (date.getDate())).slice(-2));
    }
}

//http://personal-progress-dashboard-api.azurewebsites.net/api/PersonalGoals
//http://localhost:53330/api/PersonalGoals