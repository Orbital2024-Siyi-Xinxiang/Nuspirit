/*
 * Copyright 2024 Google LLC
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

/* Automatically generated nanopb header */
/* Generated by nanopb-0.3.9.8 */

#ifndef PB_GOOGLE_FIRESTORE_ADMIN_V1_INDEX_NANOPB_H_INCLUDED
#define PB_GOOGLE_FIRESTORE_ADMIN_V1_INDEX_NANOPB_H_INCLUDED
#include <pb.h>

#include "google/api/resource.nanopb.h"

#include <string>

namespace firebase {
namespace firestore {

/* @@protoc_insertion_point(includes) */
#if PB_PROTO_HEADER_VERSION != 30
#error Regenerate this file with the current version of nanopb generator.
#endif


/* Enum definitions */
typedef enum _google_firestore_admin_v1_Index_QueryScope {
    google_firestore_admin_v1_Index_QueryScope_QUERY_SCOPE_UNSPECIFIED = 0,
    google_firestore_admin_v1_Index_QueryScope_COLLECTION = 1,
    google_firestore_admin_v1_Index_QueryScope_COLLECTION_GROUP = 2
} google_firestore_admin_v1_Index_QueryScope;
#define _google_firestore_admin_v1_Index_QueryScope_MIN google_firestore_admin_v1_Index_QueryScope_QUERY_SCOPE_UNSPECIFIED
#define _google_firestore_admin_v1_Index_QueryScope_MAX google_firestore_admin_v1_Index_QueryScope_COLLECTION_GROUP
#define _google_firestore_admin_v1_Index_QueryScope_ARRAYSIZE ((google_firestore_admin_v1_Index_QueryScope)(google_firestore_admin_v1_Index_QueryScope_COLLECTION_GROUP+1))

typedef enum _google_firestore_admin_v1_Index_State {
    google_firestore_admin_v1_Index_State_STATE_UNSPECIFIED = 0,
    google_firestore_admin_v1_Index_State_CREATING = 1,
    google_firestore_admin_v1_Index_State_READY = 2,
    google_firestore_admin_v1_Index_State_NEEDS_REPAIR = 3
} google_firestore_admin_v1_Index_State;
#define _google_firestore_admin_v1_Index_State_MIN google_firestore_admin_v1_Index_State_STATE_UNSPECIFIED
#define _google_firestore_admin_v1_Index_State_MAX google_firestore_admin_v1_Index_State_NEEDS_REPAIR
#define _google_firestore_admin_v1_Index_State_ARRAYSIZE ((google_firestore_admin_v1_Index_State)(google_firestore_admin_v1_Index_State_NEEDS_REPAIR+1))

typedef enum _google_firestore_admin_v1_Index_IndexField_Order {
    google_firestore_admin_v1_Index_IndexField_Order_ORDER_UNSPECIFIED = 0,
    google_firestore_admin_v1_Index_IndexField_Order_ASCENDING = 1,
    google_firestore_admin_v1_Index_IndexField_Order_DESCENDING = 2
} google_firestore_admin_v1_Index_IndexField_Order;
#define _google_firestore_admin_v1_Index_IndexField_Order_MIN google_firestore_admin_v1_Index_IndexField_Order_ORDER_UNSPECIFIED
#define _google_firestore_admin_v1_Index_IndexField_Order_MAX google_firestore_admin_v1_Index_IndexField_Order_DESCENDING
#define _google_firestore_admin_v1_Index_IndexField_Order_ARRAYSIZE ((google_firestore_admin_v1_Index_IndexField_Order)(google_firestore_admin_v1_Index_IndexField_Order_DESCENDING+1))

typedef enum _google_firestore_admin_v1_Index_IndexField_ArrayConfig {
    google_firestore_admin_v1_Index_IndexField_ArrayConfig_ARRAY_CONFIG_UNSPECIFIED = 0,
    google_firestore_admin_v1_Index_IndexField_ArrayConfig_CONTAINS = 1
} google_firestore_admin_v1_Index_IndexField_ArrayConfig;
#define _google_firestore_admin_v1_Index_IndexField_ArrayConfig_MIN google_firestore_admin_v1_Index_IndexField_ArrayConfig_ARRAY_CONFIG_UNSPECIFIED
#define _google_firestore_admin_v1_Index_IndexField_ArrayConfig_MAX google_firestore_admin_v1_Index_IndexField_ArrayConfig_CONTAINS
#define _google_firestore_admin_v1_Index_IndexField_ArrayConfig_ARRAYSIZE ((google_firestore_admin_v1_Index_IndexField_ArrayConfig)(google_firestore_admin_v1_Index_IndexField_ArrayConfig_CONTAINS+1))

/* Struct definitions */
typedef struct _google_firestore_admin_v1_Index {
    pb_bytes_array_t *name;
    google_firestore_admin_v1_Index_QueryScope query_scope;
    pb_size_t fields_count;
    struct _google_firestore_admin_v1_Index_IndexField *fields;
    google_firestore_admin_v1_Index_State state;

    std::string ToString(int indent = 0) const;
/* @@protoc_insertion_point(struct:google_firestore_admin_v1_Index) */
} google_firestore_admin_v1_Index;

typedef struct _google_firestore_admin_v1_Index_IndexField {
    pb_bytes_array_t *field_path;
    pb_size_t which_value_mode;
    union {
        google_firestore_admin_v1_Index_IndexField_Order order;
        google_firestore_admin_v1_Index_IndexField_ArrayConfig array_config;
    };

    std::string ToString(int indent = 0) const;
/* @@protoc_insertion_point(struct:google_firestore_admin_v1_Index_IndexField) */
} google_firestore_admin_v1_Index_IndexField;

/* Default values for struct fields */

/* Initializer values for message structs */
#define google_firestore_admin_v1_Index_init_default {NULL, _google_firestore_admin_v1_Index_QueryScope_MIN, 0, NULL, _google_firestore_admin_v1_Index_State_MIN}
#define google_firestore_admin_v1_Index_IndexField_init_default {NULL, 0, {_google_firestore_admin_v1_Index_IndexField_Order_MIN}}
#define google_firestore_admin_v1_Index_init_zero {NULL, _google_firestore_admin_v1_Index_QueryScope_MIN, 0, NULL, _google_firestore_admin_v1_Index_State_MIN}
#define google_firestore_admin_v1_Index_IndexField_init_zero {NULL, 0, {_google_firestore_admin_v1_Index_IndexField_Order_MIN}}

/* Field tags (for use in manual encoding/decoding) */
#define google_firestore_admin_v1_Index_name_tag 1
#define google_firestore_admin_v1_Index_query_scope_tag 2
#define google_firestore_admin_v1_Index_fields_tag 3
#define google_firestore_admin_v1_Index_state_tag 4
#define google_firestore_admin_v1_Index_IndexField_order_tag 2
#define google_firestore_admin_v1_Index_IndexField_array_config_tag 3
#define google_firestore_admin_v1_Index_IndexField_field_path_tag 1

/* Struct field encoding specification for nanopb */
extern const pb_field_t google_firestore_admin_v1_Index_fields[5];
extern const pb_field_t google_firestore_admin_v1_Index_IndexField_fields[4];

/* Maximum encoded size of messages (where known) */
/* google_firestore_admin_v1_Index_size depends on runtime parameters */
/* google_firestore_admin_v1_Index_IndexField_size depends on runtime parameters */

/* Message IDs (where set with "msgid" option) */
#ifdef PB_MSGID

#define INDEX_MESSAGES \


#endif

const char* EnumToString(google_firestore_admin_v1_Index_QueryScope value);
const char* EnumToString(google_firestore_admin_v1_Index_State value);
const char* EnumToString(
    google_firestore_admin_v1_Index_IndexField_Order value);
const char* EnumToString(
    google_firestore_admin_v1_Index_IndexField_ArrayConfig value);
}  // namespace firestore
}  // namespace firebase

/* @@protoc_insertion_point(eof) */

#endif
