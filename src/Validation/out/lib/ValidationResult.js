(function (global, factory) {
  if (typeof define === "function" && define.amd) {
    define(["exports", "fable-core"], factory);
  } else if (typeof exports !== "undefined") {
    factory(exports, require("fable-core"));
  } else {
    var mod = {
      exports: {}
    };
    factory(mod.exports, global.fableCore);
    global.ValidationResult = mod.exports;
  }
})(this, function (exports, _fableCore) {
  "use strict";

  Object.defineProperty(exports, "__esModule", {
    value: true
  });
  exports.ValidationResult = exports.ValidationPropertyMessage = undefined;

  function _classCallCheck(instance, Constructor) {
    if (!(instance instanceof Constructor)) {
      throw new TypeError("Cannot call a class as a function");
    }
  }

  var _createClass = function () {
    function defineProperties(target, props) {
      for (var i = 0; i < props.length; i++) {
        var descriptor = props[i];
        descriptor.enumerable = descriptor.enumerable || false;
        descriptor.configurable = true;
        if ("value" in descriptor) descriptor.writable = true;
        Object.defineProperty(target, descriptor.key, descriptor);
      }
    }

    return function (Constructor, protoProps, staticProps) {
      if (protoProps) defineProperties(Constructor.prototype, protoProps);
      if (staticProps) defineProperties(Constructor, staticProps);
      return Constructor;
    };
  }();

  var ValidationPropertyMessage = exports.ValidationPropertyMessage = function () {
    function ValidationPropertyMessage(name, message) {
      _classCallCheck(this, ValidationPropertyMessage);

      this.Name = name;
      this.Message = message;
    }

    _createClass(ValidationPropertyMessage, [{
      key: "Equals",
      value: function Equals(other) {
        return _fableCore.Util.equalsRecords(this, other);
      }
    }, {
      key: "CompareTo",
      value: function CompareTo(other) {
        return _fableCore.Util.compareRecords(this, other);
      }
    }]);

    return ValidationPropertyMessage;
  }();

  _fableCore.Util.setInterfaces(ValidationPropertyMessage.prototype, ["FSharpRecord", "System.IEquatable", "System.IComparable"], "ValidationResult.ValidationPropertyMessage");

  var ValidationResult = exports.ValidationResult = function () {
    function ValidationResult(caseName, fields) {
      _classCallCheck(this, ValidationResult);

      this.Case = caseName;
      this.Fields = fields;
    }

    _createClass(ValidationResult, [{
      key: "Equals",
      value: function Equals(other) {
        return _fableCore.Util.equalsUnions(this, other);
      }
    }]);

    return ValidationResult;
  }();

  _fableCore.Util.setInterfaces(ValidationResult.prototype, ["FSharpUnion", "System.IEquatable"], "ValidationResult.ValidationResult");
});