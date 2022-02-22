import {
  Component,
  OnInit,
  Inject,
  Input,
  Output,
  EventEmitter,
} from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import CreatePoint from 'src/app/models/CreatePoint';
import PointList from 'src/app/models/PointList';
import { PointListService } from 'src/app/services/pointList.service';

@Component({
  selector: 'app-create-point',
  templateUrl: './create-point.component.html',
  styleUrls: ['./create-point.component.sass'],
})
export class CreatePointComponent implements OnInit {
  @Input() pointListsInput: PointList[] = [];
  @Output() createPointEvent = new EventEmitter<CreatePoint>();

  public newPoint: CreatePoint = {
    xCoordinate: NaN,
    yCoordinate: NaN,
    pointListId: NaN,
  };

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    private pointListService: PointListService
  ) {}

  ngOnInit(): void {
    this.pointListService.getAll().subscribe((pointData) => {
      this.pointListsInput = pointData;
    });
  }

  public createPoint() {
    this.createPointEvent.emit(this.newPoint);
    // this.newPoint = {
    //   xCoordinate: NaN,
    //   yCoordinate: NaN,
    //   pointListId: NaN,
    // };
  }
}
