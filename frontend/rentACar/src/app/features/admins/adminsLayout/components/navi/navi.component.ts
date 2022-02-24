import { AuthService } from './../../../../../core/services/auth.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-navi',
  templateUrl: './navi.component.html',
  styleUrls: ['./navi.component.css']
})
export class NaviComponent implements OnInit {


  constructor( private authService:AuthService) { }

  ngOnInit(): void {
  }



}
