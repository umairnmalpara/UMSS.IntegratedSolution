import { ModuleWithProviders, NgModule, Optional, SkipSelf } from '@angular/core';
import { CommonModule } from '@angular/common';
import { of as observableOf } from 'rxjs';
import { AppDataProviderModule } from './app-data-provider/app-data-provider.module';
import { throwIfAlreadyLoaded } from './module-import-guard';

import {
  AnalyticsService,
  LayoutService,
} from './utils';

import { NavMenu } from './app-data/nav-menu';

import { NavMenuService } from './app-data-provider/nav-menu.service';

const DATA_SERVICES = [
  { provide: NavMenu, useClass: NavMenuService },
];

export const CORE_MODULE_PROVIDERS = [
  ...AppDataProviderModule.forRoot().providers,
  ...DATA_SERVICES,
  
  AnalyticsService,
  LayoutService,
];

@NgModule({
  imports: [
    CommonModule,
  ],
  exports: [
  ],
  declarations: [],
})

export class CoreModule {
  constructor(@Optional() @SkipSelf() parentModule: CoreModule) {
    throwIfAlreadyLoaded(parentModule, 'CoreModule');
  }

  static forRoot(): ModuleWithProviders<CoreModule> {
    return {
      ngModule: CoreModule,
      providers: [
        ...CORE_MODULE_PROVIDERS,
      ],
    };
  }
}
