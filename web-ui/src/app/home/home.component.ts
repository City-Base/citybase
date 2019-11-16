import { Component, OnInit } from '@angular/core';
import { HomeService } from '../../shared/home.service';
import { apiUrl } from '../config/apiUrl';
import { HttpClient } from '@angular/common/http';
import { FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  //===================global variables================
  searchForm: any;

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
      },
      error => {
        console.log("err",error);
      }
    );

  }

  //============initialize form=========
  ngOnInit(){

  //=========================request for states====================
    this.searchForm = this.formBuilder.group({
      country: [''],
      state: ['']
    });

  }

  //=========================do something on selecting states on change (change)="modo($event.target.value)"=====================
  getStates(value){
    this.hService.getStates(this.searchForm.value)
    .subscribe(
      (data: any) => {
        console.log("states-response", data);
      },
      error => {
        console.log("err",error);
      }
    );
  }

}
