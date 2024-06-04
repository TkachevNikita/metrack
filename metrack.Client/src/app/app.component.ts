import {Component, DestroyRef, inject, OnInit} from '@angular/core';
import {Observable} from "rxjs";
import {ContactModel} from "./models/contact.model";
import {ContactService} from "./services/contact.service";
import {MatDialog} from "@angular/material/dialog";
import {ContactDialogComponent} from "./components/contact-dialog/contact-dialog.component";
import {takeUntilDestroyed} from "@angular/core/rxjs-interop";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent implements OnInit {
    public contacts$!: Observable<ContactModel[]>;

    private _destroyRef: DestroyRef = inject(DestroyRef)

    constructor(
        private _contactService: ContactService,
        public dialog: MatDialog
    ) { }

    public ngOnInit(): void {
        this.contacts$ = this._contactService.contacts$;
    }

    public openDialog(): void {
        const dialogRef = this.dialog.open(ContactDialogComponent);

        dialogRef.afterClosed()
            .pipe(
                takeUntilDestroyed(this._destroyRef)
            )
            .subscribe({
                next: (contact) => {
                    this._contactService.createContact({
                        ...contact,
                        createdAt: new Date(),
                        photo: ''
                    })
                }})
    }
}
