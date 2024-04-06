import { Component, Input } from "@angular/core";
import { Concert } from "../../shared/models/concert";

@Component({
    selector: 'app-concert-item',
    templateUrl: './concert-item.component.html',
    styleUrls: ['./concert-item.component.scss']
})

export class ConcertItemComponent {

    @Input() concert?: Concert;


}