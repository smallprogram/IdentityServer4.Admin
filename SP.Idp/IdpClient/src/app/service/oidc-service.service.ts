import { Injectable } from '@angular/core';
import { UserManager, User } from 'oidc-client';
import { environment } from 'src/environments/environment';
import { ReplaySubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class OidcServiceService {
  private userManager: UserManager = new UserManager(environment.openIdConnectSettings);
  private currentUser: User;
  constructor() { }
}
