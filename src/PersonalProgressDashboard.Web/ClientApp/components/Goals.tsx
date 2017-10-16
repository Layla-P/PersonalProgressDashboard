import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import 'isomorphic-fetch';
import axios from "axios/index";


interface IGoals {
    goals: IGoal[]
}

interface IGoal {
    id: number;
    goalText: string;
    achieveByDate: Date;
    achievedDate: Date;
    isAchieved:boolean;
}


export class MyGoals extends React.Component<RouteComponentProps<{}>, IGoals> {
    isSubmitted: boolean = false;
    val: string;
    constructor() {
        super();
        this.state = {goals:[]}
        axios({
            method: 'get',
            //url: 'http://personal-progress-dashboard-api.azurewebsites.net/api/PersonalGoals',
            url:'http://localhost:5000/api/PersonalGoals',
            withCredentials: true 
        }).then(response => {
            console.log(response.data);
            this.setState({
                goals: response.data
            });
        });
    }
    private static renderGoals(goals: IGoal[]) {
        return <div>
            {goals.map(goal =>
                <dl className="dl-horizontal" key={goal.id}>
                    <dt>My goal is to</dt>
                    <dd>{goal.goalText}</dd>
                    <dt>I want to achieve this by</dt>
                    <dd>{goal.achieveByDate}</dd>
                    <dt>I have achieved this on</dt>
                    <dd>{ goal.isAchieved ?goal.achievedDate : "-"}</dd>
                   
                           </dl>
                       )
                   }
               </div >;

    }
    public render() {
        let goals = MyGoals.renderGoals(this.state.goals);
        return (
            
            <div>{goals}</div>
            );
    }

}


