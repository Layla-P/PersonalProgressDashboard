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
    isAchieved: boolean;
}

export class Goals extends React.Component<any, IGoals> {
    isSubmitted: boolean = false;
    val: string;
    constructor() {
        super();
        this.state = { goals: [] }
        let authHeader = "";
        let config: any = { headers: {} }

        if (localStorage !== null && localStorage.getItem("token") !== null) {
            authHeader = 'bearer ' + localStorage.getItem("token");
            config.headers.authorization = authHeader;
        }
        config.headers.withCredentials = true;
        console.log(config);
        axios.get('http://localhost:53330/api/PersonalGoals', config).then(response => {
            if (this.refs.myRef){
                this.setState({
                    goals: response.data
                });
        }
        });
    }
    private static renderGoals(goals: IGoal[]) {
        return <div ref="myRef">
            {goals.map(goal =>
                <dl className="dl-horizontal" key={goal.id}>
                    <dt>My goal is to</dt>
                    <dd>{goal.goalText}</dd>
                    <dt>I want to achieve this by</dt>
                    <dd>{goal.achieveByDate}</dd>
                    <dt>I have achieved this on</dt>
                    <dd>{goal.isAchieved ? goal.achievedDate : "-"}</dd>

                </dl>
            )
            }
        </div >;

    }
    public render() {
        let goals = Goals.renderGoals(this.state.goals);
        return (

            <div>{goals}</div>
        );
    }

}


