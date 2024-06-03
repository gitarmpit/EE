class EE_Battery extends EE_Calc {

  mAh = null;
  I = null;
  y = null;
  m = null;
  d = null;
  h = null;

  constructor() {
    super("form-battery");
    this.mAh = new EE_Calc_Float(this.form_name + "-mAh");
    this.I = new EE_Calc_I(this.form_name + "-I");
    this.y = new EE_Calc_Int(this.form_name + "-y");
    this.m = new EE_Calc_Int(this.form_name + "-m");
    this.d = new EE_Calc_Int(this.form_name + "-d");
    this.h = new EE_Calc_Int(this.form_name + "-h");
    this.init();
  }

  clear() {
    this.mAh.clear();
    this.I.clear();
    this.y.clear();
    this.m.clear();
    this.d.clear();
    this.h.clear();
  }

  calc(targetId) {

    let mAh = 0;
    let I = 0;
    let y = 0;
    let m = 0;
    let d = 0;
    let h = 0;
    let dur_set = false;
  
    try {
  
      if (!this.mAh.empty()) {
        mAh = this.mAh.getValue();
        if (mAh <= 0) {
          throw "invalid value";
        }
      }

      if (!this.I.empty()) {
        I = this.I.getValue();
      }
      
      if (!this.y.empty()) {
        y = this.y.getValue();
        dur_set = true;
      }
      if (!this.m.empty()) {
        m = this.m.getValue();
        dur_set = true;
      }
      if (!this.d.empty()) {
        d = this.d.getValue();
        dur_set = true;
      }
      if (!this.h.empty()) {
        h = this.h.getValue();
        dur_set = true;
      }
      if (mAh > 0 && I > 0 && !dur_set) {
        let amp_sec = mAh * 3.6;
        let dur_sec = amp_sec / I;
        let dur = seconds_to_YMDH(dur_sec);
        this.y.setValue (dur[0]);
        this.m.setValue (dur[1]);
        this.d.setValue (dur[2]);
        this.h.setValue (dur[3]);
      }
      else if (mAh > 0 && I == 0 && dur_set) {
        let amp_sec = mAh * 3.6;
        let dur_sec = YMDH_to_Seconds(y, m, d, h);
        I = amp_sec / dur_sec;
        this.I.setValue(I);
      }
      else if (mAh == 0 && I != 0 && dur_set) {
        let dur_sec = YMDH_to_Seconds(y, m, d, h);
        let amp_sec = I * dur_sec;
        mAh = amp_sec / 3.6;
        this.mAh.setValue(mAh);
      }
      else {
        throw "invalid parameters";
      }
  
    }
    catch (err) {
      reportError(err);
    }
    
  }

}
