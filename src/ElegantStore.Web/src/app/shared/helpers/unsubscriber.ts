import {Injectable, OnDestroy} from "@angular/core";
import {Subject} from "rxjs";

@Injectable()
export abstract class Unsubscriber implements OnDestroy {
  unsubscribe$ = new Subject<boolean>();

  ngOnDestroy(): void {
    this.unsubscribe$.next(true);
    this.unsubscribe$.complete();
  }
}
