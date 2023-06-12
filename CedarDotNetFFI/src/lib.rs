extern crate libc;

use cedar_policy::frontend::{
    is_authorized, utils, validate
};
use std::ffi::{CStr, c_char, CString};

#[no_mangle]
pub extern "C" fn Validate(s: *const c_char) -> *mut c_char {
    let c_str = unsafe {
        assert!(!s.is_null());
        CStr::from_ptr(s)
    };
    let r_str = c_str.to_str().unwrap();
    let result = validate::json_validate(r_str);
    let json_result = serde_json::to_string(&result).unwrap();
    let return_result = CString::new(json_result).unwrap();
    return_result.into_raw()
}

#[no_mangle]
pub extern "C" fn IsAuthorized(s: *const c_char) -> *mut c_char {
    let c_str = unsafe {
        assert!(!s.is_null());
        CStr::from_ptr(s)
    };
    let r_str = c_str.to_str().unwrap();
    let result = is_authorized::json_is_authorized(r_str);
    let json_result = serde_json::to_string(&result).unwrap();
    let return_result = CString::new(json_result).unwrap();
    return_result.into_raw()
}

