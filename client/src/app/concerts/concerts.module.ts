import { NgModule } from "@angular/core";
import { ConcertsComponent } from './concerts.component';
import { ConcertItemComponent } from "./concert-item/concert-item.component";
import { CommonModule } from "@angular/common";
import { SharedModule } from "../shared/shared.module";
import { ConcertsRoutingModule } from "./concerts-routing.component";
import { ConcertDetailsComponent } from "./concert-details/concert-details.component";

@NgModule({
    declarations: [
        ConcertsComponent,
        ConcertItemComponent,
        ConcertDetailsComponent
    ],
    imports:[
        CommonModule,
        SharedModule,
        ConcertsRoutingModule
    ]    
})

export class ConcertsModule {}