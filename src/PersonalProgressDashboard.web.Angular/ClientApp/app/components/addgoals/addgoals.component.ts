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
    private errorMessage: any;
    public goalForm: FormGroup; // model driven form
    public submitted: boolean; // keep track on whether form is submitted
    public formSaved: boolean; // keep track on whether form has been successfully saved
    public events: any[] = []; // use to display form changes
    private sub: any;
    private _http: Http;
    public isValid: boolean;


    constructor(private _fb: FormBuilder, http: Http) {
        this._http = http
        this.isValid = true;
        this.submitted = false;
        this.errorMessage = {
            day: null,
            month: null,
            year: null
        }
    } // form builder simplify form initialization



    ngOnInit() {
        this.submitted = false;

        this.goalForm = this._fb.group({
            id: [''],
            goalText: ['', [<any>Validators.required, <any>Validators.minLength(5), <any>Validators.maxLength(250)]],
            achieveByDateDay: ['', [<any>Validators.required]],
            achieveByDateMonth: ['', [<any>Validators.required]],
            achieveByDateYear: ['', [<any>Validators.required]],
            achievedDate: ['', [<any>Validators.required]]
        });

    }

    ngOnDestroy() {
        if (this.sub) {
            this.sub.unsubscribe();
        }
    }

    save(model: Goal) {
        if (isNaN(parseInt(model.achieveByDateDay)) || parseInt(model.achieveByDateDay) > 31 || parseInt(model.achieveByDateDay) < 0) {
            this.isValid = false;
            this.errorMessage.day = "The day must be valid";
            console.log("The day must be valid");
        }
        if (isNaN(parseInt(model.achieveByDateMonth)) || parseInt(model.achieveByDateMonth) > 12 || parseInt(model.achieveByDateDay) < 0) {
            this.isValid = false;
            this.errorMessage.month = "The month must be valid"
            console.log("The month must be valid");
        }
        if (isNaN(parseInt(model.achieveByDateYear)) /* add in a year date check*/) {
            this.isValid = false;
            this.errorMessage.year = "The year must be valid"
            console.log("The year must be valid");
        }
        if (this.isValid){
            this.errorMessage = {};
            let achieveByDate = new Date(`${model.achieveByDateYear}-${model.achieveByDateMonth}-${model.achieveByDateDay}T00:00:00Z`)
            // check if model is valid
            // if valid, call API to save customer
            let g: any = {
                "goalText": model.goalText,
                "achieveByDate": achieveByDate.toUTCString(),

            };


            let headers = new Headers({ 'Content-Type': 'application/json' });
            let options = new RequestOptions({ headers: headers }); //make sure headers are set correctly so that you avoid http415 errors (content-type accept)
            let body = JSON.stringify(g);
            console.log(body);

            return this._http.post(
                "http://localhost:53330/api/PersonalGoals",
                body,
                options
            ).subscribe(result => {
                console.log(result);
                this.submitted = true; // set form submit to true
                }, error => console.error(error));
            
        }
        this.isValid = true;
    }



    private toDateString(date: Date): string {
        return (date.getFullYear().toString() + '-'
            + ("0" + (date.getMonth() + 1)).slice(-2) + '-'
            + ("0" + (date.getDate())).slice(-2));
    }
}

//http://personal-progress-dashboard-api.azurewebsites.net/api/PersonalGoals
//http://localhost:53330/api/PersonalGoals