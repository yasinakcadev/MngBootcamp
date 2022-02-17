import { Injectable } from '@angular/core';
import {
  ActivatedRouteSnapshot,
  CanActivate,
  Router,
  RouterStateSnapshot,
  UrlTree,
} from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { AuthService } from '../services/auth.service';

@Injectable({
  providedIn: 'root',
})
export class ClaimGuard implements CanActivate {
  constructor(
    private authService: AuthService,
    private toasterService: ToastrService,
    private router: Router
  ) {}
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ):
    | Observable<boolean | UrlTree>
    | Promise<boolean | UrlTree>
    | boolean
    | UrlTree {
    const requiredClaims: string[] = route.data['requiredClaims'];
    const isAuthenticated = this.authService.isAuthenticated(requiredClaims);
    if (!isAuthenticated) {
      this.toasterService.error("You're not autharized to access");
      this.router.navigateByUrl('');

      return false;
    }

    return true;
  }
}
