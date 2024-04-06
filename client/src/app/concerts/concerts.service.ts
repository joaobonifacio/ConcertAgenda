import { Injectable } from "@angular/core";
import { Observable, map } from "rxjs";
import { Concert } from "../shared/models/concert";
import { HttpClient } from "@angular/common/http";

@Injectable({
    providedIn: 'root'
})

export class ConcertsService {

    baseUrl = 'https://localhost:7048/api/';

    constructor(private http: HttpClient){}

    getConcerts(): Observable<Concert[]>{

        return this.http.get<Concert[]>(this.baseUrl + 'concerts')
                .pipe(map(response => {
                    return response;
                }))
    }
}