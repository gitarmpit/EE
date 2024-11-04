class EE_IndCurrent extends EE_Calc {

  L = null;
  V = null;
  I = null;  
  R = null;  
  t = null;

  constructor() {
    super("form-ind");
    this.L = new EE_Calc_L(this.form_name + "-L");
    this.V = new EE_Calc_V(this.form_name + "-V");
    this.I = new EE_Calc_I(this.form_name + "-I");
    this.R = new EE_Calc_R(this.form_name + "-R");
    this.t = new EE_Calc_Time(this.form_name + "-t");
    this.init();
  }

  clear() {
    this.L.clear();
    this.V.clear();
    this.I.clear();
    this.R.clear();
    this.t.clear();
  }

  calc(targetId) {
    try {
      if (this.L.empty() && !this.V.empty() && !this.I.empty() && !this.t.empty()) {
        if (this.R.empty()) {
          this.L.setValue(this.V.getValue() * this.t.getValue() / this.I.getValue());
        } 
        else {
           this.L.setValue(-this.R.getValue() * this.t.getValue() / Math.log (-(this.I.getValue() * this.R.getValue() - this.V.getValue()) / this.V.getValue()));
        }
      } 
      else if (!this.L.empty() && this.V.empty() && !this.I.empty() && !this.t.empty()) {
        if (this.R.empty()) {
           this.V.setValue(this.L.getValue() * this.I.getValue() / this.t.getValue());
        }
        else {
           let exp = Math.exp(this.R.getValue() * this.t.getValue() / this.L.getValue());
           this.V.setValue( this.I.getValue()* this.R.getValue() * exp / (exp - 1) );
        }
      } 
      else if (!this.L.empty() && !this.V.empty() && this.I.empty() && !this.t.empty()) {
        if (this.R.empty()) {
           this.I.setValue(this.V.getValue() * this.t.getValue() / this.L.getValue());
        }
        else  {
           this.I.setValue (this.V.getValue() / this.R.getValue() * (1 - Math.exp(-this.R.getValue() * this.t.getValue() / this.L.getValue())));
        }
      } 
      else if (!this.L.empty() && !this.V.empty() && !this.I.empty() && this.t.empty()) {
        if (this.R.empty()) {
           this.t.setValue(this.I.getValue() * this.L.getValue() / this.V.getValue());
        }
        else {
           this.t.setValue (-this.L.getValue() * Math.log(-(this.I.getValue() * this.R.getValue() - this.V.getValue()) / this.V.getValue()) / this.R.getValue()); 
        }
      } 
      else {
        throw "invalid input";
      }
    }
    catch (err) {
      reportError(err);
    }
  }


}

