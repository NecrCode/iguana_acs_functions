﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XiaWorld;
using XLua;
using HarmonyLib;
using System.Reflection.Emit;

namespace iguana_acs_functions
{
    class iguana_OutspreadPopIncreaser
    {
        public static bool enabled = true; //No longer toggleable
        [HarmonyPatch(typeof(OutspreadMgr.Region), "AddPopulation")]
        public static class iguana_AddPopulation_Patch
        {
            static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
            {
                if (!enabled) { return instructions; }
                foreach (CodeInstruction codeInstruction in instructions)
                {
                    if (codeInstruction.opcode.Name == "ldc.i4" && codeInstruction.operand.ToString() == "400000")
                    {
                        int newvalue = 999990;
                        codeInstruction.operand = newvalue;
                    }
                }
                return instructions;
            }
        }
        [HarmonyPatch(typeof(OutspreadMgr.Region), "RawAddPopulation")]
        public static class iguana_RawAddPopulation_Patch
        {
            static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
            {
                if (!enabled) { return instructions; }
                foreach (CodeInstruction codeInstruction in instructions)
                {
                    if (codeInstruction.opcode.Name == "ldc.i4" && codeInstruction.operand.ToString() == "400000")
                    {
                        int newvalue = 999990;
                        codeInstruction.operand = newvalue;
                    }
                }
                return instructions;
            }
        }
        //Related to Issue/PR #29
        [HarmonyPatch(typeof(OutspreadMgr), "GetRegionPopulationAddPerday")]
        public static class iguana_GetRegionPopulationAddPerDay_Patch
        {
            static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
            {
                if (!enabled) { return instructions; }
                foreach (CodeInstruction codeInstruction in instructions)
                {
                    if (codeInstruction.opcode.Name == "ldc.i4" && codeInstruction.operand.ToString() == "40000")
                    {
                        int newvalue = 99999;
                        codeInstruction.operand = newvalue;
                    }
                }
                return instructions;
            }
        }
    }
}
