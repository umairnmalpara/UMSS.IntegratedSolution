import { Observable } from 'rxjs';

export abstract class NavMenu {
    abstract getNavMenu(): Observable<any>;
  }