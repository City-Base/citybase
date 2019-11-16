import { Component, OnInit, OnDestroy } from '@angular/core';
import { HomeService } from '../../shared/home.service';
import { apiUrl } from '../config/apiUrl';
import { HttpClient } from '@angular/common/http';
import { FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit, OnDestroy {

  //===================global variables================
  searchForm: any;
  countries = new Array;
  states = new Array;
  places_req;
  selected_state: any;

  constructor(
    private hService: HomeService,
    private http: HttpClient,
    private formBuilder: FormBuilder
  ) {
    //========================get countries onload========================
    this.hService.getCountry()
    .subscribe(
      (data: any) => {
        console.log("country-response", data);
        for(let i = 0; i < data.length; i++){
          this.countries.push(data[i]);
        }
      },
      error => {
        console.log("err",error);
      }
    );

  }

  //============initialize form=========
  ngOnInit(){

    this.searchForm = this.formBuilder.group({
      country: [''],
      state: ['']
    });

    //=========================request for states====================
    this.places_req = {
      "country": "",
      "state": "",
      "monthFrom": "",
      "monthTo": "",
      "cost": "",
      "sortByField": "",
      "sortDir": "",
    }

    localStorage.removeItem("countryId"); // to remove on refresh
  }

  //==================on change of countries==============
  getCountry(value){
    this.places_req.country = value;
    let cId = localStorage.setItem("countryId", this.places_req.country);
    this.getStates(cId);
  }

  //=========================do something on selecting states on change (change)="modo($event.target.value)"=====================
  getStates(value){
    this.selected_state = value;
    this.hService.getStates()
    .subscribe(
      (data: any) => {
        this.states = [];
        for(let i = 0; i < data.length; i++){
          this.states.push(data[i]);
        }
        console.log("states-response", data);
      },
      error => {
        console.log("err",error);
      }
    );
  }

  ngOnDestroy(){
    //just dangling here. will see if needed.
  }

}
