class EE_ripple extends EE_Calc {

  f = null;
  C = null;
  I = null;
  V = null;

  constructor() {
    super("form-ripple");
    this.f = new EE_Calc_Freq(this.form_name + "-f");
    this.C = new EE_Calc_C(this.form_name + "-C");
    this.I = new EE_Calc_I(this.form_name + "-I");
    this.V = new EE_Calc_V(this.form_name + "-V");
    this.init();
  }

  clear() {
    this.f.clear();
    this.C.clear();
    this.I.clear();
    this.V.clear();
  }

  calc(targetId) {

    let nparam = 0;
    let f = 0;
    let C = 0;
    let I = 0;
    let V = 0;
  
    try {
  
      if (!this.f.empty()) {
        f = this.f.getValue();
        ++nparam;
      }
      if (!this.C.empty()) {
        C = this.C.getValue();
        ++nparam;
      }
      if (!this.I.empty()) {
        I = this.I.getValue();
        ++nparam;
      }
      if (!this.V.empty()) {
        V = this.V.getValue();
        ++nparam;
      }

      if (nparam == 3) {
        if (V == 0) {
          V = I / (4 * f * C);
          this.V.setValue(V);
        }
        else if (I == 0) {
          I = V * 4 * f * C;
          this.I.setValue(I);
        }
        else if (C == 0) {
          C = I / (4 * f * V);
          this.C.setValue(C);
        }
        else if (f == 0) {
          f = I / (C * 4 * V);
          this.f.setValue(f);
        }
        else {
          throw "invalid parameters"
        }
      }
      else {
        throw "invalid number of parameters"
      }
  
    }
    catch (err) {
      reportError(err)
    }
  
  }


}
