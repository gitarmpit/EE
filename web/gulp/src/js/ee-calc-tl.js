class EE_tl extends EE_Calc {

  Zo = null;
  C = null;
  L = null;
  t = null;
  VF = null;
  len = null;
  Zo_default = 50;
  Vc = 3 * Math.pow(10, 8);

  constructor() {
    super("form-tl");
    this.Zo = new EE_Calc_R(this.form_name + "-Zo");
    this.C = new EE_Calc_C(this.form_name + "-C");
    this.L = new EE_Calc_L(this.form_name + "-L");
    this.VF = new EE_Calc_Float(this.form_name + "-VF");
    this.len = new EE_Calc_Len(this.form_name + "-len");
    this.t = new EE_Calc_Time(this.form_name + "-t");

    this.init();
  }

  clear() {
    this.Zo.setValue (this.Zo_default);
    this.C.clear();
    this.L.clear();
    this.t.clear();
    this.VF.clear();
    this.len.clear();
  }

  calc_t_VF(C, L, len) {
    let t0 = Math.sqrt(L * C);
    let t = t0 * len;
    this.t.setValue(t);
  
    let VF = 100 / (this.Vc * t0);
    this.VF.setValue(VF);
  }
  
  calc(targetId) {
    let Zo = 0;
    let t = 0;
    let C = 0;
    let L = 0;
    let len = 1;
    let VF = 0;
  
    try {

      if (!this.Zo.empty()) {
        Zo = this.Zo.getValue();
      }
      if (!this.C.empty()) {
        C = this.C.getValue();
      }
      if (!this.L.empty()) {
        L = this.L.getValue();
      }
      if (!this.t.empty()) {
        t = this.t.getValue();
      }
      if (!this.VF.empty()) {
        VF = this.VF.getValue();
      }
      if (!this.len.empty()) {
        len = this.len.getValue();
      }
      else {
        len = 1;
        this.len.setValue(len);
      }

      if (Zo == 0) {
        console.log (this.Zo_default);
        this.Zo.setValue (Zo);
      }
  
      this.Zo_default = Zo;
  
      let Cmin = 1 / (this.Vc * Zo);
      let Lmin = Zo / this.Vc;
  
      if (C != 0) {
        if (C < Cmin) {
          C = Cmin;
          this.C.setValue(C);
        }

        L = Zo * Zo * C;
        this.L.setValue(L);

        if (t == 0) {
          this.calc_t_VF(C, L, len);
        }
        else {
          let t0 = Math.sqrt(L * C);
          len = t / t0;
          this.len.setValue(len);

          VF = 100 / (this.Vc * t0);
          this.VF.setValue(VF);
        }
      }
      else if (L != 0) {
        if (L < Lmin) {
          L = Lmin;
          this.L.setValue(L);
        }
        
        C = L / Zo / Zo;
        this.C.setValue(C);

        if (t == 0) {
          this.calc_t_VF(C, L, len);
        }
        else {
          let t0 = Math.sqrt(L * C);
          len = t / t0;
          this.len.setValue(len);
          VF = 100 / (this.Vc * t0);
          this.VF.setValue(VF);
        }
      }
      else if (VF > 0) {
        if (VF > 100) {
          VF = 100;
          this.VF.setValue(VF);
        }
        let t0 = 100 / (VF * this.Vc);
        if (t == 0) {
          t = t0 * len;
          this.t.setValue(t);
        }
        else {
          len = t / t0;
          this.len.setValue(len);
        }
  
        C = t0 / Zo;
        L = t0 * Zo;
        this.C.setValue(C);
        this.L.setValue(L);

      }
      else if (t > 0) {
        let t0 = t / len;
        if (t0 < 1 / this.Vc) {
          t0 = 1 / this.Vc;
          t = t0 * len;
        }
  
        this.t.setValue(t);

        VF = 100 / (this.Vc * t0);
        this.VF.setValue(VF);
  
        C = t0 / Zo;
        L = t0 * Zo;
        this.C.setValue(C);
        this.L.setValue(L);

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
