/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { ReconciliationPageComponent } from './reconciliation-page.component';

describe('ReconciliationPageComponent', () => {
  let component: ReconciliationPageComponent;
  let fixture: ComponentFixture<ReconciliationPageComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ReconciliationPageComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ReconciliationPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
