import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Observable } from 'rxjs';
import { AccessTokenModel } from '../models/accessTokenModel';
import { LoginModel } from '../models/loginModel';
import { LoginResponseModel } from '../models/loginResponseModel';
import { TokenUserModel } from '../models/tokenUserModel';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  apiUrl = 'http://localhost:5228/api/Auths/';

  constructor(
    private httpClient: HttpClient,
    private jwtHelperService: JwtHelperService
  ) {}

  login(loginModel: LoginModel): Observable<LoginResponseModel> {
    let newPath = this.apiUrl + 'login';
    return this.httpClient.post<LoginResponseModel>(newPath, loginModel);
  }

  logout() {
    localStorage.removeItem('token');
  }

  isAuthenticated(requiredClaims: string[]): boolean {
    const decodedToken = this.jwtHelperService.decodeToken(
      this.jwtHelperService.tokenGetter()
    );
    if (!decodedToken) {
      return false;
    }
    const tokenUserModel: TokenUserModel = {
      id: decodedToken[
        'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier'
      ],
      email: decodedToken['email'],
      name: decodedToken[
        'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'
      ],
      claims:
        decodedToken[
          'http://schemas.microsoft.com/ws/2008/06/identity/claims/role'
        ].split(','),
    };

    if (this.jwtHelperService.isTokenExpired()) {
      this.logout();
      return false;
    }
    if (
      requiredClaims &&
      !requiredClaims.some((role) => tokenUserModel.claims.includes(role))
    ) {
      return false;
    }
    return true;
  }
}
