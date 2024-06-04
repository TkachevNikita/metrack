import {ChangeDetectionStrategy, Component, Input, OnInit} from "@angular/core";
import {ContactModel} from "../../models/contact.model";
import {Observable} from "rxjs";
import {ContactService} from "../../services/contact.service";
import {
    MatCard,
    MatCardActions,
    MatCardContent,
    MatCardHeader,
    MatCardSubtitle,
    MatCardTitle
} from "@angular/material/card";
import {MatButton} from "@angular/material/button";
import {DatePipe, NgOptimizedImage} from "@angular/common";

@Component({
    selector: 'app-contact',
    templateUrl: './conctact.component.html',
    styleUrls: ['./contact.component.scss'],
    changeDetection: ChangeDetectionStrategy.OnPush,
    imports: [
        MatCardHeader,
        MatCard,
        MatCardContent,
        MatCardActions,
        MatButton,
        MatCardSubtitle,
        MatCardTitle,
        DatePipe,
    ],
    standalone: true
})
export class ContactComponent {
    @Input({
        required: true
    })
    public contact!: ContactModel;

    constructor(private _contactService: ContactService) { }

    public removeContact(id: string): void {
        this._contactService.deleteContact(id);
    }
}
