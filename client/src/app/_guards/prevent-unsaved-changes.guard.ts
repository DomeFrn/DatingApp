import { CanDeactivateFn } from '@angular/router';
import { MemberEditComponent } from '../members/member-edit/member-edit.component';

export const preventUnsavedChangesGuard: CanDeactivateFn<MemberEditComponent> = (component) => {
  if (component.editForm?.dirty) {
    return confirm('Sind Sie sicher, dass sie fortfahren möchten? Alle ungesicherten Änderungen werden verloren gehen')
  }
  return true;
};
