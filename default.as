.PROGRAM set.feeder (.e) ; 
  ; *******************************************************************
  ;
  ; Program:      set.feeder
  ; Comment:      Send feeder value to PLC 
  ; Author:       Dmitriy Bogachev
  ; Company:      Robowizard Co. Ltd.
  ; Contact:      +79312024963
  ;
  ; Date:         8/06/2021
  ;
  ; *******************************************************************
  ;
  .feed.e1.bit = 81
  .feed.e2.bit = 97
  BITS .feed.e1.bit, 16 = INT(.e)
  BITS .feed.e2.bit, 16 = (.e - INT(.e))*10000
.END
.PROGRAM cut.feeder ()
  ; *******************************************************************
  ;
  ; Program:      cut.feeder
  ; Comment:      Send cut feeder signal to cutter
  ; Author:       Dmitriy Bogachev
  ; Company:      Robowizard Co. Ltd.
  ; Contact:      +79312024963
  ;
  ; Date:         8/06/2021
  ;
  ; *******************************************************************
  ;
  .cut_io = 32
  PULSE 32, 1
.END
.PROGRAM set.feed.temp (.temp)
  ; *******************************************************************
  ;
  ; Program:      set.feed.temp
  ; Comment:      Send feeder temperature to PLC 
  ; Author:       Dmitriy Bogachev
  ; Company:      Robowizard Co. Ltd.
  ; Contact:      +79312024963
  ;
  ; Date:         8/06/2021
  ;
  ; *******************************************************************
  ;
  .feed.temp.bit = 33
  BITS .feed.temp.bit, 16 = .temp
.END
.PROGRAM set.bed.temp (.temp)
  ; *******************************************************************
  ;
  ; Program:      set.bed.temp
  ; Comment:      Send bed temperature value to PLC
  ; Author:       Dmitriy Bogachev
  ; Company:      Robowizard Co. Ltd.
  ; Contact:      +79312024963
  ;
  ; Date:         8/06/2021
  ;
  ; *******************************************************************
  ;
  .bed.temp.bit = 49
  BITS .bed.temp.bit, 16 = .temp
.END
.PROGRAM set.fan (.value)
  ; *******************************************************************
  ;
  ; Program:      set.fan
  ; Comment:      Send fan speed value to PLC 
  ; Author:       Dmitriy Bogachev
  ; Company:      Robowizard Co. Ltd.
  ; Contact:      +79312024963
  ;
  ; Date:         8/06/2021
  ;
  ; *******************************************************************
  ;
  .fan.speed.bit = 65
  BITS .fan.speed.bit, 16 = .value
.END
.PROGRAM teach.f ()
  ; *******************************************************************
  ;
  ; Program:      teach.f
  ; Comment:      Program for teaching frame
  ; Author:       Dmitriy Bogachev
  ; Company:      Robowizard Co. Ltd.
  ; Contact:      +79312024963
  ;
  ; Date:         8/06/2021
  ;
  ; *******************************************************************
  ;
  ; !!!WARNING!!!
  ; TOOL Z+ should be same as BASE+
  ;
  BASE NULL
  ;
  LMOVE #a
  LMOVE #b
  LMOVE #c
  BREAK
  ;
  POINT a = #a
  POINT b = #b
  POINT c = #c
  ;
  POINT f = FRAME(a, b, c, a)
  
.END
.PROGRAM Comment___ () ; Comments for IDE. Do not use.
	; @@@ PROJECT @@@
	; @@@ PROJECTNAME @@@
	; default
	; @@@ HISTORY @@@
	; @@@ INSPECTION @@@
	; @@@ CONNECTION @@@
	; KROSET R01
	; 127.0.0.1
	; 9105
	; @@@ PROGRAM @@@
	; 0:set.feeder:F
	; .value 
	; .e 
	; 0:cut.feeder:F
	; 0:set.feed.temp:F
	; .temp 
	; 0:set.bed.temp:F
	; .temp 
	; 0:set.fan:F
	; .value 
	; 0:teach.f:F
	; @@@ TRANS @@@
	; @@@ JOINTS @@@
	; @@@ REALS @@@
	; @@@ STRINGS @@@
	; @@@ INTEGER @@@
	; @@@ SIGNALS @@@
	; @@@ TOOLS @@@
	; @@@ BASE @@@
	; @@@ FRAME @@@
	; @@@ BOOL @@@
	; @@@ DEFAULTS @@@
	; BASE: NULL
	; TOOL: NULL
	; @@@ WCD @@@
	; SIGNAME: sig1 sig2 sig3 sig4
	; SIGDIM: % % % %
.END
