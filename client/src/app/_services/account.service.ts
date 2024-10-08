import { HttpClient } from '@angular/common/http';
import { inject, Injectable, signal } from '@angular/core';
import { User } from '../_models/user';
import { map } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  private http = inject(HttpClient);
  baseUrl = environment.apiURL;
  currentUser = signal<User | null>(null) // Ist null wenn niemand eingeloggt ist, ist Type User, laso mit token und nutzername wenn jemand eingeloggt ist

  login(model: any) { // Schickt login anfrage an API und nutzt zurückgegebene Logindaten (wenn erfolgreich) und setzt diese auf currentUser (wird aufgereufen wenn Login gedrückt wird)
    return this.http.post<User>(this.baseUrl + 'account/login', model).pipe(
      map(user => {
        if (user) {
          localStorage.setItem('user', JSON.stringify(user));
          this.currentUser.set(user);
        }
      })
    )
  }

  register(model: any) { // Schickt register anfrage an API
    return this.http.post<User>(this.baseUrl + 'account/register', model).pipe(
      map(user => {
        if (user) {
          localStorage.setItem('user', JSON.stringify(user));
          this.currentUser.set(user);
        }
        return user;
      })
    )
  }


  logout() {
    localStorage.removeItem('user');
    this.currentUser.set(null);
  }
}
