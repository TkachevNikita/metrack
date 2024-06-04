import {ChangeDetectionStrategy, Component, Inject} from "@angular/core";
import {
    MatDialogActions,
    MatDialogContent,
    MatDialogRef,
    MatDialogTitle
} from "@angular/material/dialog";
import {MatFormField, MatHint, MatLabel} from "@angular/material/form-field";
import {MatButton} from "@angular/material/button";
import {MatInput} from "@angular/material/input";
import {FormControl, FormGroup, ReactiveFormsModule, Validators} from "@angular/forms";
import {ContactModel} from "../../models/contact.model";

@Component({
    templateUrl: './contact-dialog.component.html',
    styleUrls: ['contact-dialog.component.scss'],
    standalone: true,
    imports: [
        MatDialogContent,
        MatFormField,
        MatDialogActions,
        MatButton,
        MatInput,
        MatDialogTitle,
        MatHint,
        MatLabel,
        ReactiveFormsModule
    ],
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class ContactDialogComponent {
    public form: FormGroup;
    private selectedFile: File | null = null;

    constructor(
        public dialogRef: MatDialogRef<ContactDialogComponent>,
    ) {
        this.form = new FormGroup({
            name: new FormControl<string>('', Validators.required),
            phone: new FormControl<string>('', Validators.required),
            email: new FormControl<string>('', Validators.required),
        })
    }

    public closeDialog(): void {
        this.dialogRef.close();
    }

    public onFileSelected(event: any): void {
        this.selectedFile = event.target.files[0];
    }

    public createContact(): void {
        this.dialogRef.close({ ...this.form.value, photo: this.selectedFile });
    }
}
