import { NgModule } from '@angular/core';
import { ServerModule } from '@angular/platform-server';
import { AppModuleShared } from './app.module.shared';
import { AppComponent } from './components/app/app.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
    bootstrap: [AppComponent  ],
    imports: [
        ServerModule,
        AppModuleShared,
        ReactiveFormsModule,
        FormsModule
    ]
})
export class AppModule {
}
