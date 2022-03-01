import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import CreatePoint from 'src/app/models/CreatePoint';
import PointList from 'src/app/models/PointList';
import { PointListService } from 'src/app/services/pointList.service';

@Component({
  selector: 'app-update-point',
  templateUrl: './update-point.component.html',
  styleUrls: ['./update-point.component.sass'],
})
export class UpdatePointComponent implements OnInit {
  @Input() pointListsInput: PointList[] = [];
  @Output() updatePointEvent = new EventEmitter<CreatePoint>();

  public updatePoint: CreatePoint = {
    xCoordinate: 0,
    yCoordinate: 0,
    pointListId: 0,
  };

  constructor(
    private pointListService: PointListService,
    public dialog: MatDialog
  ) {}

  ngOnInit(): void {
    this.pointListService.getAll().subscribe((pointData) => {
      this.pointListsInput = pointData;
    });
  }

  public updatingPoint() {
    this.updatePointEvent.emit(this.updatePoint);
  }
}
