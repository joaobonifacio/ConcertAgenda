import { RouterModule, Routes } from "@angular/router";
import { ConcertsComponent } from "./concerts.component";
import { ConcertDetailsComponent } from "./concert-details/concert-details.component";
import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";

const routes: Routes = [
    { path: '', component: ConcertsComponent },
    { path: ':id', component: ConcertDetailsComponent }
]

@NgModule({
    declarations: [],
    imports: [
        CommonModule,
        RouterModule.forChild(routes)
    ],
    exports: [
        RouterModule
    ]
})

export class ConcertsRoutingModule {}