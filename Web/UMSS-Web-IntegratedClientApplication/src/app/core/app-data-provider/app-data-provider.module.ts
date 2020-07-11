import { NgModule, ModuleWithProviders } from '@angular/core';
import { CommonModule } from '@angular/common';

import { NavMenuService } from './nav-menu.service';

const SERVICES = [
  NavMenuService,
];

@NgModule({
  imports: [
    CommonModule,
  ],
  providers: [
    ...SERVICES,
  ],
})

export class AppDataProviderModule {
  static forRoot(): ModuleWithProviders<AppDataProviderModule> {
    return {
      ngModule: AppDataProviderModule,
      providers: [
        ...SERVICES,
      ],
    };
  }
}