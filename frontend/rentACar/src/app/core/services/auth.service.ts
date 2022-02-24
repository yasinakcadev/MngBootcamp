import { RegisterResponseModel } from './../models/registerResponseModel';
import { RegisterModel } from './../models/registerModel';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Observable } from 'rxjs';
import { AccessTokenModel } from '../models/accessTokenModel';
import { LoginModel } from '../models/loginModel';
import { LoginResponseModel } from '../models/loginResponseModel';
import { TokenUserModel } from '../models/tokenUserModel';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  apiUrl = 'http://localhost:5228/api/Auths/';

  constructor(
    private httpClient: HttpClient,
    private jwtHelperService: JwtHelperService,
    private router: Router
  ) {}

  login(loginModel: LoginModel): Observable<LoginResponseModel> {
    let newPath = this.apiUrl + 'login';
    return this.httpClient.post<LoginResponseModel>(newPath, loginModel);
  }
  register(registerModel: RegisterModel): Observable<RegisterResponseModel> {
    let newPath = this.apiUrl + 'register';
    return this.httpClient.post<RegisterResponseModel>(newPath, registerModel);
  }

  logout() {
    localStorage.removeItem('token');
    this.router.navigate(['login']);
  }

  decodeToken(): any {
    const decodedToken = this.jwtHelperService.decodeToken(
      this.jwtHelperService.tokenGetter()
    );
    return decodedToken;
  }
  isAuthenticated(requiredClaims: string[]): boolean {
    // const decodedToken = this.jwtHelperService.decodeToken(
    //   this.jwtHelperService.tokenGetter()
    // );
    let decodedToken = this.decodeToken();
    if (!decodedToken) {
      return false;
    }

    let userInfo = this.giveUser();

    //for new
    // const tokenUserModel: TokenUserModel = {
    //   id: decodedToken[
    //     'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier'
    //   ],
    //   email: decodedToken['email'],
    //   claims:
    //   decodedToken[
    //     'http://schemas.microsoft.com/ws/2008/06/identity/claims/role'
    //   ]?
    //     decodedToken[
    //       'http://schemas.microsoft.com/ws/2008/06/identity/claims/role'
    //     ].split(",") : []
    // };
    //___________________________________________________________________________________
    //old
    // const tokenUserModel: TokenUserModel = {
    //   id: decodedToken[
    //     'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier'
    //   ],
    //   email: decodedToken['email'],
    //   name: decodedToken[
    //     'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'
    //   ],
    //   claims:
    //   decodedToken[
    //     'http://schemas.microsoft.com/ws/2008/06/identity/claims/role'
    //   ]?
    //     decodedToken[
    //       'http://schemas.microsoft.com/ws/2008/06/identity/claims/role'
    //     ].split(",") : []
    // };

    if (this.jwtHelperService.isTokenExpired()) {
      this.logout();
      return false;
    }
    if (
      requiredClaims &&
      !requiredClaims.some((role) => userInfo.claims.includes(role))
    ) {
      return false;
    }
    return true;
  }

  giveUser(): TokenUserModel {
    let decodedToken = this.decodeToken();

    const tokenUserModel: TokenUserModel = {
      id: decodedToken[
        'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier'
      ],
      email: decodedToken['email'],
      claims: decodedToken[
        'http://schemas.microsoft.com/ws/2008/06/identity/claims/role'
      ]
        ? decodedToken[
            'http://schemas.microsoft.com/ws/2008/06/identity/claims/role'
          ].split(',')
        : [],
    };
    return tokenUserModel;
  }
}
