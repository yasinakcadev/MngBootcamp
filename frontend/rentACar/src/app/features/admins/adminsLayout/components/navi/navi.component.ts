import { AuthService } from './../../../../../core/services/auth.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navi',
  templateUrl: './navi.component.html',
  styleUrls: ['./navi.component.css'],
})
export class NaviComponent implements OnInit {
  constructor(private authService: AuthService, private router: Router) {}
  isAdmin: boolean = false;
  isLoggedIn: boolean = false;
  route: string = '';

  ngOnInit(): void {
    this.getCurrentUser();
    this.isLoggedInMethod();
  }

  getCurrentUser() {
    let user = this.authService.giveUser();
    this.isAdmin = user.claims.includes('Admin');
  }

  isLoggedInMethod() {
    if (localStorage.getItem('token') !== null) {
      this.isLoggedIn = true;
      this.route = 'login';
    }
  }

  logout() {
    this.authService.logout();
    this.isLoggedIn = false;
  }
}
