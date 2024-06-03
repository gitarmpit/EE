class EE_Battery2 extends EE_Calc {

  Ah = null;
  I = null;
  V = null;
  P = null;
  h = null;
  min = null;

  constructor() {
    super("form-battery2");
    this.Ah = new EE_Calc_Float(this.form_name + "-Ah");
    this.I = new EE_Calc_I(this.form_name + "-I");
    this.V = new EE_Calc_V(this.form_name + "-V");
    this.P = new EE_Calc_P(this.form_name + "-P");
    this.h = new EE_Calc_Int(this.form_name + "-h");
    this.min = new EE_Calc_Int(this.form_name + "-min");
    this.init();
  }

  clear() {
    this.Ah.clear();
    this.I.clear();
    this.V.clear();
    this.P.clear();
    this.h.clear();
    this.min.clear();
  }

  calc(targetId) {

    let Ah = 0;
    let I = 0;
    let V = 0;
    let P = 0;
    let h = 0;
    let min = 0;
    let dur_set = false;
  
    try {
  
      if (!this.Ah.empty()) {
        Ah = this.Ah.getValue();
        if (Ah <= 0) {
          throw "invalid value";
        }
      }

      if (!this.I.empty()) {
        I = this.I.getValue();
      }
      
      if (!this.V.empty()) {
        V = this.V.getValue();
      }

      if (!this.P.empty()) {
        P = this.P.getValue();
      }

      if (!this.h.empty()) {
        h = this.h.getValue();
        dur_set = true;
      }
      if (!this.min.empty()) {
        min = this.min.getValue();
        dur_set = true;
      }

      if (V > 0 && I > 0) {
        P = V * I;
        this.P.setValue(P);
      }
      else if (V > 0 && P > 0) {
        I = P / V;
        this.I.setValue(I);
      }
      else if (I > 0 && P > 0) {
        V = P / I;
        this.V.setValue(V);
      }

      if (Ah > 0 && I > 0 && !dur_set) {
        let amp_sec = Ah * 3600;
        let dur_sec = amp_sec / I;
        let dur = seconds_to_HM(dur_sec);
        this.h.setValue (dur[0]);
        this.min.setValue (dur[1]);
      }
      else if (Ah > 0 && I == 0 && dur_set) {
        let amp_sec = Ah * 3600;
        let dur_sec = HM_to_Seconds(h, min);
        I = amp_sec / dur_sec;
        this.I.setValue(I);
        if (P > 0) {
          V = P / I;
          this.V.setValue(V);
        }
        else if (V > 0) {
          P = V * I;
          this.P.setValue(P);
        }
      }
      else if (Ah == 0 && I != 0 && dur_set) {
        let dur_sec = HM_to_Seconds(h, min);
        let amp_sec = I * dur_sec;
        Ah = amp_sec / 3600;
        this.Ah.setValue(Ah);
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
