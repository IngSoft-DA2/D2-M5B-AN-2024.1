import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ParentComponentComponent } from './components/parent-component/parent-component.component';
import { ItemComponentComponent } from './components/item-component/item-component.component';
import { Da2ServicesService } from './services/da2-services.service';

@NgModule({
  declarations: [
    AppComponent,
    ParentComponentComponent,
    ItemComponentComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [Da2ServicesService],
  bootstrap: [AppComponent]
})
export class AppModule { }
