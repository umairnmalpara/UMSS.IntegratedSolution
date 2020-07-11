import { Component, OnInit } from '@angular/core';
import { NavMenu } from 'src/app/core/app-data/nav-menu';
import { takeUntil } from 'rxjs/operators';
import { Subject } from 'rxjs';

@Component({
  selector: 'umss-default-layout',
  templateUrl: './default-layout.component.html',
  styleUrls: []
})
export class DefaultLayoutComponent implements OnInit {

  private destroy$: Subject<void> = new Subject<void>();
  public sidebarMinimized = false;
  public navItems : any;

  constructor(
    private navMenuService : NavMenu
  ) 
  { }

  toggleMinimize(e) {
    this.sidebarMinimized = e;
  }

  ngOnInit(): void {
    this.navMenuService.getNavMenu()
      .pipe(takeUntil(this.destroy$))
      .subscribe(
        (nav: any) => 
        this.navItems = nav
        );
  }

  ngOnDestroy() {
    this.destroy$.next();
    this.destroy$.complete();
  }

}
