import { Component, OnInit, Input } from '@angular/core';
import { PairingModel } from '../shared/line.model';

@Component({
  selector: 'app-line-pairing',
  templateUrl: './line-pairing.component.html',
  styleUrls: ['./line-pairing.component.css']
})
export class LinePairingComponent implements OnInit {
  @Input() pairings: PairingModel[];

  constructor() { }

  ngOnInit() {
  }

}
