import * as React from 'react';
import { RouteComponentProps } from 'react-router';

export class Home extends React.Component<RouteComponentProps<{}>, {}> {
    public render() {
        return <div>
            <div className="panel panel-primary" >
                <div className="panel-heading">
                    Welcome
                </div>
                <div className="panel-body">
                    <div className="row">
                        <div className='col-md-12'>
                            <h1 id="ProgressDemoMainHeader">Personal Progress Demo - ReactJS</h1>

                            <p><i>(Start demo by clicking the 'My Goals' link to the left)</i></p>

                            <ul>
                                <li>Microsoft Technologies (ASP.NET Core 2 MVC / WebAPI / EF to SQL Server)</li>
                                <li>Open Source Technologies (Node.js (for tooling), ReactJS, TypeScript, WebPack, Gulp)</li>
                            </ul>

                            <p>
                                This website is a technology demo showcasing the full-stack development of a small website. It comprises an Asp.Net Core 2
                    back-end paired with a ReactJS UI.  The intended audience are technologists who will have relevant knowledge and experience
                    of the subject matter.
                </p>

                            <p>
                                This app is intentionally simple - the purpose of this demo is not an extensive
                    end-product, but rather a showcase of a vertical stack.  This, alongside the
                    architecture, technology stack and development processes that underpin the system, presents a near complete
                    solution. It would now be straightforward to scale this up and
                    develop a significantly larger and more complex application.
                </p>


                            <p>
                                <b>
                                    You can find the entire open-source for this project here:
                        <a href="https://github.com/Layla-P/PersonalProgressDashboard">https://github.com/ Layla-P/ PersonalProgressDashboard</a>
                                </b>
                            </p>

                        </div>

                    </div>
                </div>
            </div>



            <div className="panel panel-primary" >
                <div className="panel-heading">
                    Features
             </div>
                <div className="panel-body">


                    <div className="row">

                        <div className="col-md-4" >

                            <h3>
                                Back-end :
                </h3>
                            <ul>

                                <li>Entity-Framework Core (Code-First) to an MS SqlServer Db</li>
                                <li>
                                    Fluent-API to describe the database (as opposed to use of "data-annotations"" on domain models).
                        <br />
                                    <a href="https://github.com/Layla-P/PersonalProgressDashboard/tree/master/src/PersonalProgressDashboard.Data/EntitiesConfigurations" target="_blank">
                                        <i className="fa fa-hand-pointer-o fa-lg"></i> See "PersonalProgressDashboard.Data/ EntityConfigurations".
                        </a>
                                </li>

                                <li>
                                    Database repository-pattern.
                        <br />
                                    <a href="https://github.com/Layla-P/PersonalProgressDashboard/tree/master/src/PersonalProgressDashboard.Data/Repositories" target="_blank">
                                        <i className="fa fa-hand-pointer-o fa-lg"></i> See "PersonalProgressDashboard.Data/ Repositories".
                        </a>
                                </li>

                                <li>
                                    WebAPI is used to present a Restful api layer to the client application.
                        <br />
                                    <a href="https://github.com/Layla-P/PersonalProgressDashboard/tree/master/src/PersonalProgressDashboard.Api/Controllers" target="_blank">
                                        <i className="fa fa-hand-pointer-o fa-lg"></i>
                                        <i>See "PersonalProgressDashboard.Api" project.</i>
                                    </a>
                                </li>
                            </ul>
                        </div>

                        <div className="col-md-4">

                            <h3>
                                Environment :
                </h3>
                            <ul>
                                <li>Developed using a primarily Visual Studio 2017</li>
                                <li>
                                    Hosted in Azure, using App services (a "Web App" and separate "API App")
                        alongside an Azure SQL Db.
                    </li>
                                <li>Development using GitHub for source control (using branches for CI workflow).</li>
                                <li>Master branch on GitHub is associated via an Azure-KUDU-based CI, deploying directly to production websites.</li>
                                <li>
                                    TWO WEBSERVERS :   The main website is a separate VS project/server to the server hosting the WebAPI.
                        Clearly overkill for a microsite like this, it is intended to demonstrate that you can scale the two interconnected
                        systems in the cloud separately (e.g. if your api is being heavily loaded).
                        <br />
                                    <i className="fa fa-hand-pointer-o fa-lg"></i> CORS is used to allow cross domain access.
                        <br />
                                    <i className="fa fa-hand-pointer-o fa-lg"></i> Azure is configured to deploy the appropriate project to appropriate servers.
                    </li>
                                <li>User auth has been implented using dotnet identity provider and JWT tokens and the front end has just begun to be tied in.</li>
                                <li>Logging has not yet been added to this demo, that will come later.</li>
                            </ul>
                        </div>

                        <div className="col-md-4" >
                            <h3>
                                Client-side application and build process :
                </h3>

                            <ul>
                                <li>
                                    ReactJS app written with TSX; work in progress
                        <a href="https://github.com/Layla-P/PersonalProgressDashboard/tree/master/src/PersonalProgressDashboard.web/ClientApp" target="_blank">
                                        <i className="fa fa-hand-pointer-o fa-lg"></i>
                                        <i> See "App" sub-project.</i>
                                    </a>
                                </li>

                                <li>
                                    "WebPack" package building, to bundle the project into a single js package.
                    </li>

                                <li>
                                    "Bootstrap" and "Font-Awesome" for responsive UI.
                    </li>

                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>;
    }
}