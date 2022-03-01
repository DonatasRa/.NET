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
import Point from 'src/app/models/Point';
import PointList from 'src/app/models/PointList';
import { PointService } from 'src/app/services/point.service';
import { PointListService } from 'src/app/services/pointList.service';
import { StateService } from 'src/app/services/state.service';

@Component({
  selector: 'app-create-point',
  templateUrl: './create-point.component.html',
  styleUrls: ['./create-point.component.sass'],
})
export class CreatePointComponent implements OnInit {
  @Input() pointListsInput: PointList[] = [];

  public newPoint: CreatePoint = {
    xCoordinate: 0,
    yCoordinate: 0,
    pointListId: 0,
  };
  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    private pointListService: PointListService,
    private stateService: StateService
  ) {}

  ngOnInit(): void {
    this.pointListService.getAll().subscribe((pointListData) => {
      this.pointListsInput = pointListData;
    });
  }

  public createPoint() {
    this.stateService.create(this.newPoint);
  }
}
